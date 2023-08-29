using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFVehicleTypeLists;

namespace NewLMS.UMKM.MediatR.Features.RFVehicleTypeLists.Commands
{
    public class RFVehicleTypeListPostValidator : AbstractValidator<RFVehicleTypeListPostCommand>
    {
        public RFVehicleTypeListPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}