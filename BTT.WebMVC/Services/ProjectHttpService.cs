using AutoMapper;
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using BTT.WebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class ProjectHttpService : IProjectHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ProjectHttpService(HttpClient httpClient, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
        }

        public async Task<bool> Add(ProjectViewModel projectVM)
        {
            var projectDto = _mapper.Map<ProjectViewModel, ProjectDto>(projectVM);

            var projectDtoContent = new StringContent(JsonSerializer.Serialize(projectDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync(string.Empty, projectDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Add(Guid projectId, MemberViewModel memberVM)
        {
            var memberDto = _mapper.Map<MemberViewModel, MemberDto>(memberVM);

            var memberDtoContent = new StringContent(JsonSerializer.Serialize(memberDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync($"p={projectId}", memberDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Add(Guid memberId, Guid projectId, IssueViewModel issueVM)
        {
            var issueDto = _mapper.Map<IssueViewModel, IssueDto>(issueVM);

            var issueDtoContent = new StringContent(JsonSerializer.Serialize(issueDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync($"m={projectId}/p={projectId}", issueDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> Edit(ProjectViewModel projectVM)
        {
            var projectDto = _mapper.Map<ProjectViewModel, ProjectDto>(projectVM);

            var projectDtoContent = new StringContent(JsonSerializer.Serialize(projectDto), Encoding.UTF8, "application/json");

            var putTask = await _httpClient.PutAsync(string.Empty, projectDtoContent);

            return putTask.IsSuccessStatusCode;
        }

        public async Task<ProjectViewModel> Get(Guid projectId)
        {
            return await JsonSerializer.DeserializeAsync<ProjectViewModel>
                (await _httpClient.GetStreamAsync($"p={projectId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> Remove(Guid projectId)
        {
            var deleteTask = await _httpClient.DeleteAsync($"p={projectId}");

            return deleteTask.IsSuccessStatusCode;
        }
    }
}
