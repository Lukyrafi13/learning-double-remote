﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Documents;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechRedemption.UIM.Models;

namespace NewLMS.Umkm.MediatR.Features.Documents.Queries
{
    public class DocumentsGetByIdQuery : IRequest<ServiceResponse<DocumentResponse>>
    {
        public Guid Id { get; set; }
    }

    public class DocumentsGetByIdQueryHandler : IRequestHandler<DocumentsGetByIdQuery, ServiceResponse<DocumentResponse>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;

        public DocumentsGetByIdQueryHandler(
            IGenericRepositoryAsync<Document> repo, 
            IGenericRepositoryAsync<User> user, 
            IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DocumentResponse>> Handle(DocumentsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "RfDocumentStatus",
                    "RfDocument",
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<DocumentResponse>.Return404("Dokumen tidak ditemukan.");

                var dataVm = _mapper.Map<DocumentResponse>(data);


                //var dataUser = await _user.GetByIdAsync(data.CreatedBy);
                foreach (var f in dataVm.Files.ToList())
                {
                    //f.FileUrl.UploadBy = dataUser.FirstName + " " + dataUser.LastName;
                    f.FileUrl.Url = f.FileUrl.Url.Replace(@"\", @"/");
                    f.FileUrl.FileName = f.FileUrl.Url.Split('/').Last();
                }

                return ServiceResponse<DocumentResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DocumentResponse>.ReturnException(ex);
            }
        }
    }
}
