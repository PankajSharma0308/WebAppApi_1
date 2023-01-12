using WebAppApi_1.Models.DTO;

namespace WebAppApi_1.Data
{
    public static class ItemData
    {
        public static List<ItemModelDTO> itemList = new List<ItemModelDTO>
        {
            new ItemModelDTO{Id = 1, Name="Pankaj"},
            new ItemModelDTO{Id = 2, Name="Sharma"},
            new ItemModelDTO{Id = 3, Name="Hello"}
        };
    }
}
