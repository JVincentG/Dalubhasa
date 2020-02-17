/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 2/17/2020
 * Time: 9:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace dalubhasa02
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.KeyPreview = true;
		}
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Q)
			{
				button1.PerformClick();
			}
			if (e.KeyCode == Keys.W)
			{
				button2.PerformClick();
			}
			if (e.KeyCode == Keys.E)
			{
				button2.PerformClick();
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			MessageBox.Show("You Clicked Button 1");
		}
		void Button2Click(object sender, EventArgs e)
		{
			MessageBox.Show("You Clicked Button 2");
		}
		void Button3Click(object sender, EventArgs e)
		{
			MessageBox.Show("You Clicked Button3");
		}
	}
}
