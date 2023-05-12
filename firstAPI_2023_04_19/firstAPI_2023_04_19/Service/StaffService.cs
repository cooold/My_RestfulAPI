using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.IService;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Parameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace firstAPI_2023_04_19.Service
{
    public class StaffService : IQueryStaff
    {
        private readonly RestfulApiTestContext _restfulApiTestContext;
        public StaffService(RestfulApiTestContext restfulApiTestContext)
        {
            _restfulApiTestContext = restfulApiTestContext;
        }
        public async Task<List<StaffSelectDto>>? QueryStaff(StaffSelectParameters value)
        {
            var result = _restfulApiTestContext.Staff
                .Select(a => new StaffSelectDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Phone = a.Phone,
                    Department = a.Department
                });

            if (!string.IsNullOrEmpty(value.Name))
            {
                result = result.Where(a => a.Name == value.Name);
            }

            if (!string.IsNullOrEmpty(value.Phone))
            {
                result = result.Where(a => a.Phone == value.Phone);
            }
            if (!string.IsNullOrEmpty(value.Department))
            {
                result = result.Where(a => a.Department == value.Department);
            }

            return await result.ToListAsync();
        }
        public async Task<StaffSelectDto>? QueryStaffByid(int id)
        {
            var result = _restfulApiTestContext.Staff
            .Where(a => a.Id == id)
            .Select(a => new StaffSelectDto
            {
                Id = a.Id,
                Name = a.Name,
                Phone = a.Phone,
                Department = a.Department
            });

            return await result.SingleOrDefaultAsync();
        }
        public async Task<Staff> InsertStaff(StaffPostDto value)
        {
            Staff insert = new Staff();
            _restfulApiTestContext.Staff.Add(insert).CurrentValues.SetValues(value);
            await _restfulApiTestContext.SaveChangesAsync();
            return insert;
        }
        public async Task<bool> PutStaff(int id, StaffPutDto value)
        {
            var update = _restfulApiTestContext.Staff
            .Where(a => a.Id == id)
            .Select(a => a).SingleOrDefault();

            if (update != null)
            {
                _restfulApiTestContext.Update(update).CurrentValues.SetValues(value);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> PatchStaff(int id, JsonPatchDocument value)
        {
            var update = _restfulApiTestContext.Staff
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
        public async Task<List<Staff_InfoMessagesDto>>? QueryStaffMessages(StaffSelectParameters value)
        {
            var result = _restfulApiTestContext.Staff
                .Include(a => a.InfoMessages)
                .Select(a => new Staff_InfoMessagesDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Department = a.Department,
                    Phone = a.Phone,
                    InfoMessages = a.InfoMessages
                });
            if (!string.IsNullOrEmpty(value.Name))
            {
                result = result.Where(a => a.Name == value.Name);
            }

            if (!string.IsNullOrEmpty(value.Department))
            {
                result = result.Where(a => a.Department == value.Department);
            }

            if (!string.IsNullOrEmpty(value.Phone))
            {
                result = result.Where(a => a.Phone == value.Phone);
            }
            return await result.ToListAsync();
        }
        public async Task<Staff_InfoMessagesDto>? QueryStaffMessagesByid(int id)
        {
            var result = _restfulApiTestContext.Staff
                .Include(a => a.InfoMessages)
                .Where(a => a.Id == id)
                .Select(a => new Staff_InfoMessagesDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Department = a.Department,
                    Phone = a.Phone,
                    InfoMessages = a.InfoMessages
                });
            return await result.SingleOrDefaultAsync();
        }
        public async Task<bool> DeleteStaff(int id)
        {
            var delete_child = _restfulApiTestContext.InfoMessages
                .Where(a => a.StaffId == id)
                .Select(a => a);
            if (delete_child != null)
            {
                _restfulApiTestContext.InfoMessages.RemoveRange(delete_child);
                await _restfulApiTestContext.SaveChangesAsync();
            }

            var delete = _restfulApiTestContext.Staff
            .Where(a => a.Id == id)
            .Select(a => a).SingleOrDefault();
            if (delete != null)
            {
                _restfulApiTestContext.Staff.Remove(delete);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteStaffs(List<int> ids)
        {
            var delete_child = _restfulApiTestContext.InfoMessages
                .Where(a => ids.Contains(a.StaffId))
                .Select(a => a);
            if (delete_child != null)
            {
                _restfulApiTestContext.InfoMessages.RemoveRange(delete_child);
                await _restfulApiTestContext.SaveChangesAsync();
            }

            var deletes = _restfulApiTestContext.Staff
            .Where(a => ids.Contains(a.Id))
            .Select(a => a);
            if (deletes != null && deletes.Count() >= 1)
            {
                _restfulApiTestContext.Staff.RemoveRange(deletes);
                await _restfulApiTestContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
