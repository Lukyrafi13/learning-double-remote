using FluentValidation;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabels.Commands
{
    public class BiayaVariabelPostValidator : AbstractValidator<BiayaVariabelPostCommand>
    {
        public BiayaVariabelPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}