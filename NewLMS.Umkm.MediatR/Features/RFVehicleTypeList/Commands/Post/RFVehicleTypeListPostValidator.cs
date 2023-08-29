using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFVehicleTypeLists;

namespace NewLMS.Umkm.MediatR.Features.RFVehicleTypeLists.Commands
{
    public class RFVehicleTypeListPostValidator : AbstractValidator<RFVehicleTypeListPostCommand>
    {
        public RFVehicleTypeListPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}