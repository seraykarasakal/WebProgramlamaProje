﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
	public interface ICommentService
	{

        void CommentAdd(Comment Comment);
       // void CategoryDelete(Comment category);
        //void CategoryUpdate(Comment category);
        List<Comment> GetList(int id);
        //Category GetById(int id);
    }
}