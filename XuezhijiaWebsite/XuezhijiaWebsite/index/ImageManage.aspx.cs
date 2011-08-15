﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace XuezhijiaWebsite.Index
{
    public partial class ImageManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView_Image.DataSource = (new IndexImageWrapper()).getall();
                GridView_Image.DataBind();
            }
        }

        protected void GridView_Image_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            (new IndexImageWrapper()).deleteARecordByID(Convert.ToInt32(GridView_Image.DataKeys[e.RowIndex].Value.ToString()));
            GridView_Image.DataBind();
        }

        protected void GridView_Image_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_Image.EditIndex = e.NewEditIndex;

        }

        protected void GridView_Image_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
         
            INDEXIMAGE indeximage = new INDEXIMAGE();
            indeximage.ID = Convert.ToInt32(GridView_Image.DataKeys[e.RowIndex].Value.ToString());
            indeximage.ImageSrc = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            indeximage.ImageTitle = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            indeximage.ImageTitle = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            (new IndexImageWrapper()).addAClassRecord(indeximage);
            GridView_Image.DataSource = (new IndexImageWrapper()).getall();
            GridView_Image.DataBind();
        }

        protected void GridView_Image_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Image.EditIndex = -1;
        }
    }
}