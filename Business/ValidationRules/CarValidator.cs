using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Araba markası boş geçilemez");
            RuleFor(x => x.Brand).MinimumLength(2).WithMessage("Marka ismi 2 karakterden az olamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori bilgisi boş geçilemez");
        }
    }
}
