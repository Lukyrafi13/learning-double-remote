using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikRequests;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.IO;

namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Commands
{
    public class SlikRequestProsesKontingensiCommand : IRequest<byte[]>
    {
        public List<SlikRequestFind> listSlikRequestFinds;
    }
    public class SlikRequestProsesKontingensiCommandHandler : IRequestHandler<SlikRequestProsesKontingensiCommand, byte[]>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IMapper _mapper;

        public SlikRequestProsesKontingensiCommandHandler(
                IGenericRepositoryAsync<LoanApplication> LoanApplication,
                IGenericRepositoryAsync<SlikRequest> SlikRequest,
                IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
                IMapper mapper
            )
        {
            _LoanApplication = LoanApplication;
            _SlikRequest = SlikRequest;
            _SlikRequestObject = SlikRequestObject;
            _mapper = mapper;
        }

        public string GetKodeBelakang(SlikRequestObject SlikRequestObject)
        {
            string kodeBelakang = "";
            if (SlikRequestObject.SlikObjectTypeId == 1)
            {
                kodeBelakang = SlikRequestObject.NoIdentity;
            }

            if (SlikRequestObject.SlikObjectTypeId == 2)
            {
                kodeBelakang = SlikRequestObject.NPWP;
            }

            return kodeBelakang;
        }

        public async Task<byte[]> Handle(SlikRequestProsesKontingensiCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var response = new byte[] { };
                var listGuid = new List<Guid>();

                foreach (var reqDto in request.listSlikRequestFinds)
                {
                    listGuid.Add(reqDto.Id);
                }

                var listSlikRequest = await _SlikRequest.GetListByPredicate(x => listGuid.Contains(x.Id), new string[] {
                    "LoanApplication",
                    "LoanApplication.Prospect",
                    "LoanApplication.Prospect.Stage",
                    "SlikRequestObjects",
                });

                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter objstreamwriter = new StreamWriter(stream);

                    foreach (var SlikRequest in listSlikRequest)
                    {

                        SlikRequest.AdminVerified = 1;

                        await _SlikRequest.UpdateAsync(SlikRequest);

                        foreach (var SlikRequestObject in SlikRequest.SlikRequestObjects)
                        {
                            var appId = SlikRequest?.LoanApplication?.LoanApplicationId != null ? SlikRequest.LoanApplication.LoanApplicationId.Replace("-", "") : null;
                            string kodeRef = $"{appId}_M|01|I|{GetKodeBelakang(SlikRequestObject)}";
                            objstreamwriter.WriteLine(kodeRef, Environment.NewLine);
                            SlikRequestObject.KodeRefPengguna = kodeRef;
                            await _SlikRequestObject.UpdateAsync(SlikRequestObject);
                        }

                    }

                    objstreamwriter.Flush();
                    objstreamwriter.Close();

                    response = stream.ToArray();
                }


                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}