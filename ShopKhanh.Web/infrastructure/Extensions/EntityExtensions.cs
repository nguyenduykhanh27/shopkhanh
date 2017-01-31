using ShopKhanh.Model.Models;
using ShopKhanh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopKhanh.Web.infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postcategory, PostCategoryViewModel postCategoryVm)
        {

            postcategory.ID = postCategoryVm.ID;
            postcategory.Name = postCategoryVm.Name;
            postcategory.Alias = postCategoryVm.Alias;
            postcategory.Description = postCategoryVm.Description;
            postcategory.ParentID = postCategoryVm.ParentID;
            postcategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postcategory.Image = postCategoryVm.Image;
            postcategory.CreatedDate = postCategoryVm.CreatedDate;
            postcategory.CreatedBy = postCategoryVm.CreatedBy;
            postcategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postcategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postcategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postcategory.MetaDescription = postCategoryVm.MetaDescription;
            postcategory.Status = postCategoryVm.Status;        
        }
        public static void UpdatePost(this Post post, Post postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Image = postVm.Image;
            post.Description = postVm.Description;
            post.Content = postVm.Content;
            post.HomeFlag = postVm.HomeFlag;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;
            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;

        }
    }
}