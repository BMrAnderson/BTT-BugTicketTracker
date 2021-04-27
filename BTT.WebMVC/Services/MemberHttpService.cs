using AutoMapper;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using BTT.WebMVC.Models.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class MemberHttpService : IMemberHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public MemberHttpService(HttpClient httpClient, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
        }

        public async Task<bool> Add(MemberViewModel memberVM)
        {
            var memberDto = _mapper.Map<MemberViewModel, MemberDto>(memberVM);

            var memberDtoContent = new StringContent(JsonSerializer.Serialize(memberDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync(string.Empty, memberDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Add(Guid memberId, ProjectViewModel projectVM)
        {
            var projectDto = _mapper.Map<ProjectViewModel, ProjectDto>(projectVM);

            var projectDtoContent = new StringContent(JsonSerializer.Serialize(projectDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync($"m={memberId}", projectDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Edit(MemberViewModel memberVM)
        {
            var memberDto = _mapper.Map<MemberViewModel, MemberDto>(memberVM);

            var memberDtoContent = new StringContent(JsonSerializer.Serialize(memberDto), Encoding.UTF8, "application/json");

            var putTask = await _httpClient.PutAsync(string.Empty, memberDtoContent);

            return putTask.IsSuccessStatusCode;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _httpClient.GetFromJsonAsync<bool>($"{email}");
        }

        public async Task<MemberViewModel> Get(Guid memberId)
        {
            return await JsonSerializer.DeserializeAsync<MemberViewModel>
                 (await _httpClient.GetStreamAsync($"m={memberId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> Remove(Guid memberId)
        {
            var deleteTask = await _httpClient.DeleteAsync($"m={memberId}");

            return deleteTask.IsSuccessStatusCode;
        }
    }
}
