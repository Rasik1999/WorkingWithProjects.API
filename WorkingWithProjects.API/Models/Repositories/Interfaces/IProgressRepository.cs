﻿using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> GetAllProgress();
        Progress GetProgressById(int progressId);
        Progress GetProgressByProjectId(int projectId);
        Progress UpdateProgress(Progress progress);
        Progress CreateBlankProgress(int projectId);
        Progress CreateProgress(int projectId, decimal value);
        Progress DeletePogress(int id);
    }
}
