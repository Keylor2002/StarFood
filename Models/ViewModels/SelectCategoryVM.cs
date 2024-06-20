using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models.ViewModels
{
    public class SelectCategoryVM
    {
        [ValidateNever]
        public int CategoryID { get; set; }
        [ValidateNever]
        public string Name { get; set; }
        [ValidateNever]
        public bool IsSelected { get; set; }
    }
}
