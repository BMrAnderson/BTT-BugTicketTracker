using AutoMapper;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using BTT.WebMVC.Models.ViewModels;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class OrganizationHttpService : IOrganizationHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private const string applicationJsonMediaType = "application/json";
        
        public OrganizationHttpService(HttpClient httpClient, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
        }

        public async Task<bool> Add(string organizationName)
        {
            var organizationNameContent = new StringContent(organizationName, Encoding.UTF8, applicationJsonMediaType);

            var postTask = await _httpClient.PostAsync(string.Empty, organizationNameContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Add(Guid organizationId, ProjectViewModel projectVM)
        {
            var projectDto = _mapper.Map<ProjectViewModel, ProjectDto>(projectVM);

            var projectDtoContent = new StringContent(JsonSerializer.Serialize(projectDto), Encoding.UTF8, applicationJsonMediaType);

            var postTask = await _httpClient.PostAsync($"p={organizationId}", projectDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Add(Guid organizationId, MemberViewModel memberVM)
        {
            var memberDto = _mapper.Map<MemberViewModel, MemberDto>(memberVM);

            var memberDtoContent = new StringContent(JsonSerializer.Serialize(memberDto), Encoding.UTF8, applicationJsonMediaType);

            var postTask = await _httpClient.PostAsync($"p={organizationId}", memberDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<OrganizationViewModel> Get(Guid organzationId)
        {
            return await JsonSerializer.DeserializeAsync<OrganizationViewModel>
                (await _httpClient.GetStreamAsync($"o={organzationId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> Remove(Guid organizationId)
        {
            var deleteTask = await _httpClient.DeleteAsync($"o={organizationId}");

            return deleteTask.IsSuccessStatusCode;
        }
    }
}
