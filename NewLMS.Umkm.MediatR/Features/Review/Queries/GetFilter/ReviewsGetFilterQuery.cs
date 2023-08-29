using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Reviews;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.Reviews.Queries
{
    public class ReviewsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ReviewTableResponse>>>
    {
    }

    public class ReviewsGetFilterQueryHandler : IRequestHandler<ReviewsGetFilterQuery, PagedResponse<IEnumerable<ReviewTableResponse>>>
    {
        private IGenericRepositoryAsync<Review> _Review;
        private readonly IMapper _mapper;

        public ReviewsGetFilterQueryHandler(
            IGenericRepositoryAsync<Review> Review,
            IMapper mapper)
        {
            _Review = Review;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ReviewTableResponse>>> Handle(ReviewsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "App.SiklusUsahaPokok",
                "App.DataPekerjaan",
                "App.StatusPerkawinan",
                "App.PendidikanTerakhir",
                "App.StatusTempatTinggal",
                "App.KodePos",
                "App.KodePosKontakDarurat",
                "App.JenisProduk",
                "App.BookingOffice",
                "App.Prospect",
                "App.TipeDebitur",
                "App.Prospect.ProspectStageLogs",
                "App.Prospect.ProspectStageLogs.RFStages",
                "Prescreening",
                "Survey",
                "Analisa",
                "Analisa.Survey",
                "SlikRequest",
            };

            var data = await _Review.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<ReviewTableResponse>>(data.Results);
            IEnumerable<ReviewTableResponse> dataVm;
            var listResponse = new List<ReviewTableResponse>();

            foreach (var res in data.Results){
                var response = new ReviewTableResponse();

                response.Id = res.Id;
                response.App = res.App;
                response.Prescreening = res.Prescreening;
                response.Survey = res.Survey;
                response.Analisa = res.Analisa;
                response.SlikRequest = res.SlikRequest;
                response.Age = res.Age;
                
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<ReviewTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}