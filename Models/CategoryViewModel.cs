using System.ComponentModel.DataAnnotations.Schema;

namespace ListaTracker.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; } = Constants.CategoryTypeConstants.Expense;
        public string? TitleWithIcon
        {
            get
            {
                return $"{this.Icon} {this.Title}";
            }
        }
    }
}
