using Azure;
using Azure.AI.OpenAI;
using ClinicAppointmentSystem.Services;
using Microsoft.EntityFrameworkCore;
using OpenAI.Chat;
using System;

namespace ClinicAPI.Services
{
    public class AIService : IAIService
    {
        private readonly IConfiguration _configuration;
        private readonly AzureOpenAIClient _client;
        private readonly IPatientService _patientService;

        public AIService(IConfiguration configuration, IPatientService patientService)
        {
            _configuration = configuration;

            _client = new AzureOpenAIClient(
                new Uri(_configuration["AzureOpenAI:Endpoint"]),
                new AzureKeyCredential(_configuration["AzureOpenAI:Key"]));
            _patientService = patientService;

        }

        public async Task<string> AnalyzeSymptoms(string symptoms)
        {
            string deploymentName =
                _configuration["AzureOpenAI:DeploymentName"];

            ChatClient chatClient =
                _client.GetChatClient(deploymentName);

            var response = await chatClient.CompleteChatAsync(
            [
                new SystemChatMessage(
                    "You are a helpful medical assistant."),

                new UserChatMessage(
                    $"Analyze these symptoms: {symptoms}")
            ]);

            return response.Value.Content[0].Text;
        }
        public async Task<string> GeneratePatientSummary(int patientId)
        {
            var patient = await _patientService.GetPatientById(patientId);

            if (patient == null)
                return "Patient not found";

            var visitHistory = string.Join("\n",
                patient.Visits.Select(v =>
                    $"Date: {v.VisitDate}, Symptoms: {v.Symptoms}, Diagnosis: {v.Diagnosis}"));

            var prompt = $@"
You are a medical assistant AI.

Summarize the following patient history for a doctor.

Patient Name: {patient.Name}
Age: {patient.Age}

Visit History:
{visitHistory}

Provide:
1. Clinical summary
2. Key observations
3. Risk level
";

            string deploymentName =
                _configuration["AzureOpenAI:DeploymentName"];

            ChatClient chatClient =
                _client.GetChatClient(deploymentName);

            var response = await chatClient.CompleteChatAsync(
            [
                new SystemChatMessage(
            "You are a helpful medical assistant."),

        new UserChatMessage(prompt)
            ]);

            return response.Value.Content[0].Text;
        }
    }

}