﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Documents;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveys.Queries
{
    public class DocumentSurveyGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<DocumentSurveyResponse>>>
    {
    }

    public class DocumentSurveyGetFilterQueryHandler : IRequestHandler<DocumentSurveyGetFilterQuery, PagedResponse<IEnumerable<DocumentSurveyResponse>>>
    {
        private readonly IGenericRepositoryAsync<Data.Entities.Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;

        public DocumentSurveyGetFilterQueryHandler(
            IGenericRepositoryAsync<Data.Entities.Document> repo,
            IGenericRepositoryAsync<User> user,
            IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<DocumentSurveyResponse>>> Handle(DocumentSurveyGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "Files",
                "Files.FileUrl",
            };
            var data = await _repo.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<DocumentSurveyResponse>>(data.Results);

            foreach (DocumentSurveyResponse doc in dataVm)
            {
                //var uploader = "ANONYM";
                var Files = doc.Files.ToList();

                foreach (DocumentFileUrlRes files in Files)
                {
                    //var dataUser = await _user.GetByPredicate(x => x.Id == files.CreatedBy);
                    //if (dataUser != null)
                    //{
                    //    uploader = dataUser.FirstName + " " + dataUser.LastName;
                    //}
                    //files.FileUrl.UploadBy = uploader;
                    files.FileUrl.Url = files.FileUrl.Url.Replace(@"\", @"/").Replace(@"\\", @"/");
                    files.FileUrl.FileName = files.FileUrl.Url.Split('/').Last();
                }
            }

            return new PagedResponse<IEnumerable<DocumentSurveyResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
