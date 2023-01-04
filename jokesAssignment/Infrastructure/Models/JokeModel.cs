using System;
namespace Infrastructure
{
    public class JokeModel
    {
        public sucessModel Sucess { get; set; }
        public ContentModel<CatagoryModel> Contents { get; set; }
    }
}
