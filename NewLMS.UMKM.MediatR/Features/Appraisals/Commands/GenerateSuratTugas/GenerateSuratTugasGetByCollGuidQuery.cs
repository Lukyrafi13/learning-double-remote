using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.GenerateFiles;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands.GenerateSuratTugas
{
    public class GenerateSuratTugasGetByCollGuidQuery : IRequest<ServiceResponse<GeneratedFileResponse>>
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }

    public class GenerateSuratTugasGetByCollGuidQueryHandler : IRequestHandler<GenerateSuratTugasGetByCollGuidQuery, ServiceResponse<GeneratedFileResponse>>
    {
        private IGenericRepositoryAsync<GeneratedFiles> _generatedFile;
        private readonly IMapper _mapper;

        public GenerateSuratTugasGetByCollGuidQueryHandler(IGenericRepositoryAsync<GeneratedFiles> generatedFile, IMapper mapper)
        {
            _generatedFile = generatedFile;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GeneratedFileResponse>> Handle(GenerateSuratTugasGetByCollGuidQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]
                {
                    "GeneratedFileGroups"
                };
                var data = await _generatedFile.GetByPredicate(
                    x => x.LoanApplicationCollateralGuid == request.LoanApplicationCollateralId
                    && x.GeneratedFileGroupGuid == GeneratedFileGroup.SuratPeninjauanAppr, includes);
                if (data == null)
                    return ServiceResponse<GeneratedFileResponse>.Return404("Data Generated File Not Found.");
                var dataVm = _mapper.Map<GeneratedFileResponse>(data);
                return ServiceResponse<GeneratedFileResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<GeneratedFileResponse>.ReturnException(ex);
            }

        }
    }
}
