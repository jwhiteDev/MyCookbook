using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    public class RecipeModel
    {
        public List<IngredientData> Ingredients { get; set; }
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is RecipeModel)
            {
                var other = (RecipeModel)obj;
                return Title.Equals(other.Title);
            }

            return base.Equals(obj);
        }
    }

}
