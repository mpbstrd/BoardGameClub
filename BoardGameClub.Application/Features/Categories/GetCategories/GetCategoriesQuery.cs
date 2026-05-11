using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Categories.GetCategories
{
    public class GetCategoriesQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
