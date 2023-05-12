using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.IService;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Parameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace firstAPI_2023_04_19.Service
{
    public class InfoMessagesService : IQueryInfoMessages
    {
        private readonly RestfulApiTestContext _restfulApiTestContext;
        public InfoMessagesService(RestfulApiTestContext restfulApiTestContext)
        {
            _restfulApiTestContext = restfulApiTestContext;
        }

        public async Task<List<InfoMessageSelectDto>>? QueryInfoMessages(InfoMessageSelectParameters value)
        {
            var result =  _restfulApiTestContext.InfoMessages
                .Include(a => a.Staff)
                .Select(a => new InfoMessageSelectDto
                {
                    Id = a.Id,
                    StaffName = a.Staff.Name,
                    Text = a.Text
                });

            if (!string.IsNullOrEmpty(value.name))
            {
                result = result.Where(a => a.StaffName == value.name);
            }

            if (!string.IsNullOrEmpty(value.text))
            {
                result = result.Where(a => a.Text == value.text);
            }

            return await result.ToListAsync();
        }
        public async Task<InfoMessageSelectDto>? QueryInfoMessagesByid(int id)
        {
            var result = _restfulApiTestContext.InfoMessages
                .Include(a => a.Staff)
                .Where(a => a.Id == id)
                .Select(a => new InfoMessageSelectDto
                {
                Id = a.Id,
                StaffName = a.Staff.Name,
                Text = a.Text
                });
            return await result.SingleOrDefaultAsync();
        }
        public async Task<InfoMessage> InsertInfoMessage(infoMessagePostDto value)
        {
            InfoMessage insert = new InfoMessage();
            _restfulApiTestContext.InfoMessages.Add(insert).CurrentValues.SetValues(value);
            await _restfulApiTestContext.SaveChangesAsync();
            return insert;
        }
        public async Task<bool> PutInfoMessage(int id, infoMessagePutDto value)
        {
            var update = _restfulApiTestContext.InfoMessages
            .Where(a => a.Id == id)
            .Select(a => a).SingleOrDefault();

            if(update != null)
            {
                _restfulApiTestContext.Update(update).CurrentValues.SetValues(value);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> PatchInfoMessage(int id, JsonPatchDocument value)
        {
            var update = _restfulApiTestContext.InfoMessages
            .Where(a => a.Id == id)
            .Select(a => a).SingleOrDefault();

            if (update != null)
            {
                value.ApplyTo(update);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteInfoMessage(int id)
        {
            var delete = _restfulApiTestContext.InfoMessages
            .Where(a => a.Id == id)
            .Select(a => a).SingleOrDefault();
            if (delete != null)
            {
                _restfulApiTestContext.InfoMessages.Remove(delete);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteInfoMessages(List<int> ids)
        {
            var deletes = _restfulApiTestContext.InfoMessages
            .Where(a=> ids.Contains(a.Id))
            .Select(a => a);
            if (deletes != null && deletes.Count() >= 1)
            {
                _restfulApiTestContext.InfoMessages.RemoveRange(deletes);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
