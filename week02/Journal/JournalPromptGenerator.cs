using System;
using System.Collections.Generic;

namespace Journal
{
    public class JournalPromptGenerator
    {
        private readonly List<string> _prompts;
        private readonly Random _random;

        public JournalPromptGenerator()
        {
            _random = new Random();
            _prompts = new List<string>
            {
                "What are three things you're grateful for today?",
                "Describe a challenge you recently overcame and what you learned.",
                "What boundaries do you need to set or maintain?",
                "Write about a person who changed your life.",
                "What would you do if you knew you couldn't fail?",
                "Describe your ideal day from start to finish.",
                "What negative thought patterns do you want to change?",
                "Write a letter to your future self one year from now.",
                "What are your top five values and how do they guide your decisions?",
                "Describe a recent moment of joy in detail.",
                "What habits would you like to develop or break?",
                "Write about something you need to forgive yourself for.",
                "What does success mean to you?",
                "Describe a skill you'd like to master and why.",
                "What are you avoiding right now and why?",
                "Write about a difficult decision you're facing.",
                "What has been your biggest accomplishment so far this year?",
                "Describe your relationship with failure.",
                "What would you do differently if you had more time?",
                "Write about something you've been putting off and why.",
                "What personal narratives are no longer serving you?",
                "Describe three things that made you smile recently.",
                "What are your strengths and how can you leverage them more?",
                "Write about something you're looking forward to.",
                "What would you tell your younger self if you could?"
            };
        }

        public string GetPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}