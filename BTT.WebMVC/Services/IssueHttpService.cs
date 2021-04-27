using AutoMapper;
using BTT.Application.Services.Issues;
using BTT.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class IssueHttpService : IIssueHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        
        public IssueHttpService(HttpClient httpClient, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
        }

        public async Task<bool> Add(IssueViewModel issueVM)
        {
            var issueDto = _mapper.Map<IssueViewModel, IssueDto>(issueVM);

            var issueDtoContent = new StringContent(JsonSerializer.Serialize(issueDto), Encoding.UTF8, "application/json");

            var postTask = await _httpClient.PostAsync(string.Empty, issueDtoContent);

            return postTask.IsSuccessStatusCode;
        }

        public async Task<bool> AddAttachment(Guid issueId, AttachmentViewModel attachmentVM)
        {
            var attachmentDto = _mapper.Map<AttachmentViewModel, AttachmentDto>(attachmentVM);

            var attachmentDtoContent = new StringContent(JsonSerializer.Serialize(attachmentDto), Encoding.UTF8, "application/json");

            var putTask = await _httpClient.PutAsync($"i={issueId}", attachmentDtoContent);

            return putTask.IsSuccessStatusCode;
        }

        public async Task<bool> AddComment(Guid issueId, CommentViewModel commentVM)
        {
            var commentDto = _mapper.Map<CommentViewModel, CommentDto>(commentVM);

            var commentDtoContent = new StringContent(JsonSerializer.Serialize(commentDto), Encoding.UTF8, "application/json");

            var putTask = await _httpClient.PutAsync($"i={issueId}", commentDtoContent);

            return putTask.IsSuccessStatusCode;
        }

        public async Task<bool> Edit(IssueViewModel issueVM)
        {       
            var issueDto = _mapper.Map<IssueViewModel, IssueDto>(issueVM);

            var issueDtoContent = new StringContent(JsonSerializer.Serialize(issueDto), Encoding.UTF8, "application/json");

            var putTask = await _httpClient.PutAsync(string.Empty, issueDtoContent);

            return putTask.IsSuccessStatusCode;
        }

        public async Task<IssueViewModel> Get(Guid issueId)
        {
            return await JsonSerializer.DeserializeAsync<IssueViewModel>
                (await _httpClient.GetStreamAsync($"i={issueId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<IssueViewModel>> GetAllbyMemberId(Guid memberId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<IssueViewModel>>
                 (await _httpClient.GetStreamAsync($"m={memberId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<IssueViewModel>> GetAllbyProjectId(Guid projectId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<IssueViewModel>>
                (await _httpClient.GetStreamAsync($"p={projectId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> Remove(Guid issueId)
        {
            var deleteTask = await _httpClient.DeleteAsync($"i={issueId}");
            
            return deleteTask.IsSuccessStatusCode;
        }
    }
}
