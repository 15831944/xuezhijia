﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;

namespace XuezhijiaWebsite
{
    public partial class GREManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            InitPage();
        }

        private void InitPage()
        {
            CourseWrapper wrapper = new CourseWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Courses.DataSource = table;
            Courses.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Courses.DataKeys[e.RowIndex].Value);
            CourseWrapper wrapper = new CourseWrapper();
            wrapper.deleteARecordByID(id);

        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Courses.DataKeys[Courses.SelectedIndex + 1].Value);
            CourseWrapper wrapper = new CourseWrapper();
            COURSE course = new COURSE();
            course = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(course.PID);
            wrapper.deleteARecordByID(id);
            InitPage(); 
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName; //获得name
            int Id = Convert.ToInt32(e.CommandArgument);
            COURSE course = new COURSE();
            CourseWrapper wrapper = new CourseWrapper();
            course = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;
            CourseWrapper coursewrapper = new CourseWrapper();
            string teacher = coursewrapper.getTeacherNameByID(Id);

            TextBox1.Text = course.CourseName;
            TextBox2.Text = course.Lessons.ToString();
            TextBox3.Text = course.Location.ToString();
            TextBox4.Text = course.Time.ToString();
            TextBox5.Text = course.MaxNumber.ToString();
            TextBox6.Text = course.TID.ToString();
            TextBox7.Text = course.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + course.PID.ToString();
            Image1.Visible = true;
            Session.Add("CourseID", Id);
        }

        protected void UploadClicked(object sender, EventArgs e)
        {
            string filename = Upload.FileName;
            byte[] data = Upload.FileBytes;
            string comment = Comment.Text;
            Photo.PhotoDataTable table = new Photo.PhotoDataTable();
            Photo.PhotoRow row = table.NewPhotoRow();
            row.Data = data;
            row.Comment = comment;
            row.PName = filename;
            PhotoWrapper wrapper = new PhotoWrapper();
            wrapper.addARecord(row);
        }

        protected void CommitClick(object sender, EventArgs e)
        {/*
            if (Session["CourseID"] != null && Session["CourseID"].ToString() != "")
            {
               
                int id = Convert.ToInt32(Session["CourseID"].ToString());
                COURSE tmp = new COURSE();
                CourseWrapper wrapper  = new CourseWrapper();
                tmp = wrapper.getResultByID(id);
                COURSE course = new COURSE();
                course.CourseName = TextBox1.Text ;
                course.Lessons = Convert.ToInt32(TextBox2.Text);
                course.Location = TextBox3.Text;
                course.Time = TextBox4.Text;
                course.MaxNumber = Convert.ToInt32(TextBox5.Text);
                course.TID = Convert.ToInt32(TextBox6.SelectedValue);
                course.Comment = TextBox7.Text;
                course.CourseID = id;
                course.PID = tmp.PID;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PID);
                    addAPhoto();
                    CommenHelper helper = CommenHelper.GetInstance();
                    course.PID = helper.getIdent("Photo");
                }
                
                wrapper.updateARecord(course);
                Session.Remove("CourseID");
            }

            else
            {
                COURSE tmp = new COURSE();
                CourseWrapper wrapper = new CourseWrapper();
                COURSE course = new COURSE();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                course.PID = helper.getIdent("Photo");
                course.Type = TextBox1.Text;
                course.SeatsCounts = Convert.ToInt32(TextBox2.Text);
                course.Price = Convert.ToDouble(TextBox3.Text);
                course.HirePrice = Convert.ToDouble(TextBox4.Text);
                course.AdditionalPerKM = Convert.ToDouble(TextBox5.Text);
                course.AdditionalPerHour = Convert.ToDouble(TextBox6.Text);
                course.Comment = TextBox7.Text;
                wrapper.addAClassRecord(course);
            }*/
            PostInit();
            InitPage();
        }

        public void addAPhoto()
        {
            PhotoWrapper photowrapper = new PhotoWrapper();
            Photo.PhotoRow row = new Photo.PhotoDataTable().NewPhotoRow();
            row.Comment = Comment.Text;
            row.Data = Upload.FileBytes;
            row.PName = Upload.FileName;
            photowrapper.addARecord(row);
        }

        protected void PostInit()
        {
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;

            Image1.Visible = false;
            Upload.Visible = false;
            LabelComment.Visible = false;
            Comment.Visible = false;
            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        { 
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

        }
    }
}