using FluentValidation;
using NewLMS.Umkm.Data.Dto.BiayaVariabelTenagaKerjas;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabelTenagaKerjas.Commands
{
    public class BiayaVariabelTenagaKerjaPostValidator : AbstractValidator<BiayaVariabelTenagaKerjaPostCommand>
    {
        public BiayaVariabelTenagaKerjaPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}