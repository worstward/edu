﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Domain.Models;


namespace Edu.Domain.Abstract
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
    }
}
