﻿using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models;
public class Issue : TextEntry
{
    private string title = "";
    public string Title 
    { 
        get => title;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("title cannot be empty");
            }
            title = value;
        }
    }

    public bool IsClosed { get; set; }

    public List<Answer> Answers { get; set; } = new List<Answer>();

    public override string ToString()
    {
        string qString = $"Id: {Id} Title: {Title} \nDate Created: {DateCreated} \nContent: {Content} \nScore: {Score}";
        if(Answers.Count > 0)
        {
            qString += "\n Answers: \n";
            foreach(Answer ans in Answers)
            {
                qString += ans.ToString() + "\n";
            }
        }
        return  qString;
    }

    public string GetAnswers()
    {
        StringBuilder aString = new StringBuilder();
        for (int i = 0; i < Answers.Count; i++)
        {
            aString.Append($"Answer #{i + 1}: Answers[i].Content \n");
        }
        return aString.ToString();
    }

}