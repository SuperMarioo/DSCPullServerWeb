﻿using DSCPullServerWeb.Models;
using System.Collections.Generic;

namespace DSCPullServerWeb.Services
{
    /// <summary>
    /// Interface for the database repository. Get node and report data
    /// from the DSC database.
    /// </summary>
    public interface IDatabaseRepository
    {
        IList<Node> GetNodes();

        IList<Report> GetReports();
    }
}
