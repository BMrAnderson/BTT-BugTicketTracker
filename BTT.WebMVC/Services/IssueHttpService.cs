using BTT.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public class IssueHttpService : IIssueHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IssueHttpService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public bool Add(IssueViewModel issueVM)
        {
            var http = _httpClientFactory.CreateClient("Issue");
            
            var postTask = http.PostAsJsonAsync<IssueViewModel>(string.Empty, issueVM, null, cancellationToken: default);
            
            postTask.Wait();

            return postTask.Result.IsSuccessStatusCode;
        }

        public bool AddAttachment(Guid issueId, AttachmentViewModel attachmentVM)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var putTask = http.PutAsJsonAsync<AttachmentViewModel>($"i={issueId}", attachmentVM, null, cancellationToken: default);

            putTask.Wait();

            return putTask.Result.IsSuccessStatusCode;
        }

        public bool AddComment(Guid issueId, CommentViewModel commentVM)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var putTask = http.PutAsJsonAsync<CommentViewModel>($"i={issueId}", commentVM, null, cancellationToken: default);

            putTask.Wait();

            return putTask.Result.IsSuccessStatusCode;
        }

        public bool Edit(IssueViewModel issueVM)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var postTask = http.PutAsJsonAsync<IssueViewModel>(string.Empty, issueVM, null, cancellationToken: default);

            postTask.Wait();

            return postTask.Result.IsSuccessStatusCode;
        }

        public IssueViewModel Get(Guid issueId)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var getTask = http.GetAsync($"i={issueId}");

            getTask.Wait();

            var result = getTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<IssueViewModel>();
                
                readTask.Wait();

                return readTask.Result;
            }
            return null;
        }

        public IEnumerable<IssueViewModel> GetAllbyMemberId(Guid memberId)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var getTask = http.GetAsync($"m={memberId}");

            getTask.Wait();

            var result = getTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<IssueViewModel>>();

                readTask.Wait();

                return readTask.Result;
            }
            return null;
        }

        public IEnumerable<IssueViewModel> GetAllbyProjectId(Guid projectId)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var getTask = http.GetAsync($"p={projectId}");

            getTask.Wait();

            var result = getTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<IssueViewModel>>();

                readTask.Wait();

                return readTask.Result;
            }
            return null;
        }

        public bool Remove(Guid issueId)
        {
            var http = _httpClientFactory.CreateClient("Issue");

            var removeTask = http.DeleteAsync($"i={issueId}");

            removeTask.Wait();

            var result = removeTask.Result;

            return result.IsSuccessStatusCode;
        }
    }
}
