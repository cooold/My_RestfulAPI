using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Parameters;
using Microsoft.AspNetCore.JsonPatch;

namespace firstAPI_2023_04_19.IService
{
    public interface IQueryInfoMessages
    {
        public Task<List<InfoMessageSelectDto>>? QueryInfoMessages(InfoMessageSelectParameters value);
        public Task<InfoMessageSelectDto>? QueryInfoMessagesByid(int id);
        public Task<InfoMessage> InsertInfoMessage(infoMessagePostDto value);
        public Task<bool> PutInfoMessage(int id, infoMessagePutDto value);
        public Task<bool> PatchInfoMessage(int id, JsonPatchDocument value);
        public Task<bool> DeleteInfoMessage(int id);
        public Task<bool> DeleteInfoMessages(List<int> ids);
    }

    public interface IQueryStaff
    {
        public Task<List<StaffSelectDto>>? QueryStaff(StaffSelectParameters value);
        public Task<StaffSelectDto>? QueryStaffByid(int id);
        public Task<Staff> InsertStaff(StaffPostDto value);
        public Task<bool> PutStaff(int id, StaffPutDto value);
        public Task<bool> PatchStaff(int id, JsonPatchDocument value);
        public Task<bool> DeleteStaff(int id);
        public Task<bool> DeleteStaffs(List<int> ids);
        public Task<List<Staff_InfoMessagesDto>>? QueryStaffMessages(StaffSelectParameters value);
        public Task<Staff_InfoMessagesDto>? QueryStaffMessagesByid(int id);
    }

}
