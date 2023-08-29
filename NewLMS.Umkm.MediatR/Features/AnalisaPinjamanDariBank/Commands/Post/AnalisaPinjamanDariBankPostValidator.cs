using FluentValidation;
using NewLMS.Umkm.Data.Dto.AnalisaPinjamanDariBanks;

namespace NewLMS.Umkm.MediatR.Features.AnalisaPinjamanDariBanks.Commands
{
    public class AnalisaPinjamanDariBankPostValidator : AbstractValidator<AnalisaPinjamanDariBankPostCommand>
    {
        public AnalisaPinjamanDariBankPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}