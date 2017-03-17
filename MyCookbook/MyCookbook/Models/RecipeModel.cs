using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    public class RecipeModel
    {
        public List<IngredientDetail> Ingredients { get; set; }
        public string Title { get; set; }

    }
}
