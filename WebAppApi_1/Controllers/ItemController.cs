using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppApi_1.Data;
using WebAppApi_1.Logging;
using WebAppApi_1.Models;
using WebAppApi_1.Models.DTO;


//namespace WebAppApi_1.Controllers
//{

//	[ApiController]
//	[Route("[controller]")]
//	public class ItemController : ControllerBase {

//		[HttpGet]
//    public ActionResult<ItemModelDTO> GetAllItem()
//    {
//        if (ItemData.itemList.Equals(null)) return BadRequest();

//        return Ok(ItemData.itemList);
//    }

//    [HttpGet("{id:int}")]
//    public ActionResult<ItemModelDTO> GetItem(int id)
//    {
//        if (id == 0) return BadRequest();
//        if (ItemData.itemList.Equals(null)) return NotFound();

//        return Ok(ItemData.itemList.Find(u => u.Id == id));
//    }

//    [HttpPost]
//    public ActionResult<ItemModelDTO> PostItem([FromBody] ItemModelDTO item)
//    {
//        if (item.Id == 0 || item.Name.Equals(null)) return BadRequest();
//        item.Id = ItemData.itemList.Last().Id+1;
//        ItemData.itemList.Add(item);

//        return Ok(item.Id + " " + item.Name + " " + "Created.");
//    }

//    [HttpDelete("{id:int}")]
//    public ActionResult<ItemModelDTO> DeleteItem(int id)
//    {
//        if (id == 0) return BadRequest();
//        var item = ItemData.itemList.Find(u => u.Id == id);
//        if (item.Equals(null)) return NotFound();

//        ItemData.itemList.Remove(item);

//        return Ok("Deleted");

//    }

//    [HttpPut("{id:int}")]
//    public ActionResult<ItemModelDTO> UpdateItem(int id, string? name)
//    {
//         if (id == 0 || name.Equals(null)) return BadRequest();
//         var item = ItemData.itemList.FirstOrDefault(u => u.Id == id);
//         if (item.Equals(null)) return NotFound();

//         item.Name = name;
//         return Ok("Created");

//        }
//    }

//}

namespace WebAppApi_1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ItemController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly ILogging _logger;
        
        public ItemController(ILogging logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemModelDTO>> GetAllItems()
        {
            _logger.Log("Get All Items.", "");
            return Ok(_db.Items);
        }


        [HttpGet("{id:int}", Name = "GetItem")]
        [ProducesResponseType(typeof(ItemModelDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ItemModelDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ItemModelDTO> GetItem(int id)
        {
            var item = _db.Items.FirstOrDefault(u => u.Id == id);

            if (id == 0) return BadRequest();
            if (item == null) return NotFound();

            return Ok(item);
        }


        [HttpPost]
        public ActionResult<ItemModelDTO> PostItems([FromBody] ItemModelDTO item)
        {
            if (item == null) return BadRequest();

            ItemModel model = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                CreatedDate = DateTime.Now
            };

            _db.Items.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id:int}", Name = "DeleteItem")]
        public ActionResult<ItemModelDTO> DeleteItem(int id)
        {
            var item = _db.Items.FirstOrDefault(u => u.Id == id);

            if (item == null) return BadRequest();

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok(item.Id.ToString() + " " + item.Name?.ToString() + " Deleted");
        }

        [HttpPut("{id:int}", Name = "UpdateItem")]
        public ActionResult<ItemModelDTO> UpdateItem(int id, [FromBody]ItemModelDTO items)
        {
            if (id == 0) return BadRequest();
            //var item = ItemData.itemList.FirstOrDefault(u => u.Id == id);

            if (items == null) return NoContent();

            //item.Name = item.Name;
            //item.Description = items.Description;
            //return CreatedAtRoute("GetItem", new { id = item.Id }, item);

            ItemModel model = new()
            {
                Id = items.Id,
                Name = items.Name,
                Description = items.Description,
                CreatedDate = DateTime.Now
            };
            
            _db.Items.Update(model);
            _db.SaveChanges();

            return Ok(id + " Created.");

        }

        [HttpPatch("{id:int}", Name ="UpdatePatchDetail")]
        public ActionResult<ItemModelDTO> UpdatePatchDetail(int id, JsonPatchDocument<ItemModelDTO> patchDTO)
        {
            if(patchDTO == null || id == 0) return BadRequest();
           

            var item = _db.Items.AsNoTracking().FirstOrDefault(u => u.Id == id); //Find does not work with _db, but FirstOrDefault Does, AsNoTracking ensures that entityframework doesn't track same Id simultaneously.

            ItemModelDTO modelDTO = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            if (item == null) return NotFound();

            patchDTO.ApplyTo(modelDTO);

            ItemModel model = new()
            {
                Id = modelDTO.Id,
                Name = modelDTO.Name,
                Description = modelDTO.Description,
                CreatedDate = DateTime.UtcNow
            };
            _db.Items.Update(model);
            _db.SaveChanges();

            return Ok("Patched");
        }
    }
}

