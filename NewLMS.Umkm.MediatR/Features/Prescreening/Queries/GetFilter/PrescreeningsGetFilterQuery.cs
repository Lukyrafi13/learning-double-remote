using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prescreenings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.Prescreenings.Queries
{
    public class PrescreeningsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<PrescreeningTableResponse>>>
    {
    }

    public class PrescreeningsGetFilterQueryHandler : IRequestHandler<PrescreeningsGetFilterQuery, PagedResponse<IEnumerable<PrescreeningTableResponse>>>
    {
        private IGenericRepositoryAsync<Prescreening> _Prescreening;
        private IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public PrescreeningsGetFilterQueryHandler(
            IGenericRepositoryAsync<Prescreening> Prescreening,
            IGenericRepositoryAsync<AppAgunan> AppAgunan,
            IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC,
            IMapper mapper)
        {
            _Prescreening = Prescreening;
            _AppAgunan = AppAgunan;
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PrescreeningTableResponse>>> Handle(PrescreeningsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "App.KodePos",
                "App.JenisProduk",
                "App.BookingOffice",
                "App.Prospect",
                "App.TipeDebitur",
                "App.Prospect.ProspectStageLogs",
                "App.Prospect.ProspectStageLogs.RFStages",
                "SlikRequest",
            };

            var data = await _Prescreening.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<PrescreeningTableResponse>>(data.Results);
            IEnumerable<PrescreeningTableResponse> dataVm;
            var listResponse = new List<PrescreeningTableResponse>();

            foreach (var res in data.Results){
                var response = new PrescreeningTableResponse();

                response.Id = res.Id;

                response.TanggalRequest = DateTime.Now;
                response.StatusSLIK = "1/1";

                response.App = res.App;
                response.Age = res.Age;
                response.SlikRequest = res.SlikRequest;

                var listAgunan = await _AppAgunan.GetListByPredicate(x=> x.AppId == res.App.Id, new string[] {"JenisJaminan"});
                var listJenisAgunan = new List<RFColLateralBC>();

                foreach (var agunan in listAgunan){
                    if (agunan.JenisJaminan == null){
                        continue;
                    }

                    var colateral = await _RFColLateralBC.GetByIdAsync(agunan.JenisJaminan.ColCode, "ColCode");

                    if (!listJenisAgunan.Contains(colateral)){
                        listJenisAgunan.Add(colateral);
                    }
                }

                response.ListJenisAgunan = listJenisAgunan;
                
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<PrescreeningTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}