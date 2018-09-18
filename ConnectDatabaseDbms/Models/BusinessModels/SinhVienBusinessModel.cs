using ConnectDatabaseDbms.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.BusinessModels
{
    public class SinhVienBusinessModel : DataBusinessModel<SinhVien>
    {
        // CHUA TEST
        public override SinhVien Add(SinhVien model)
        {
            try
            {
                string sql = $"EXEC AddStudent '{model.MSSV}', N'{model.TenSV}', '{model.NgaySinh}', '{model.Lop}', {model.Nu}, '{model.DienThoai}', N'{model.DiaChi}', {model.Diem}";
                int res = database.ExecuteNonQuery(sql, CommandType.Text);
                return res > 0 ? model : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ROI
        public override SinhVien Delete(SinhVien model)
        {
            try
            {
                string sql = $"EXEC dbo.DeleteStudent '{model.MSSV}'";
                int res = database.ExecuteNonQuery(sql, CommandType.Text);
                return res > 0 ? model : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // CHUA TEST
        public override SinhVien Get(params object[] keys)
        {
            try
            {
                string sql = $"SELECT * FROM GetStudent('{keys[0]}')";
                DataSet sinhVienSet = database.ExecuteQuery(sql, CommandType.Text);
                if (sinhVienSet.Tables.Count > 0)
                {
                    DataTable sinhVienTable = sinhVienSet.Tables["SinhVien"];
                    if (sinhVienTable.Rows.Count > 0)
                    {
                        DataRow row = sinhVienTable.Rows[0];
                        return new SinhVien
                        {
                            MSSV = (string)row["MSSV"],
                            TenSV = (string)row["TenSV"],
                            NgaySinh = (DateTime)row["NgaySinh"],
                            Lop = (string)row["Lop"],
                            Nu = (bool)row["GioiTinh"],
                            DienThoai = (string)row["DienThoai"],
                            DiaChi = (string)row["DiaChi"],
                            Diem = (float)row["Diem"]
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ROI
        public override List<SinhVien> GetAll()
        {
            try
            {
                string sql = $"SELECT * FROM GetAllStudent()";
                using (DataSet sinhVien = database.ExecuteQuery(sql, CommandType.Text))
                {
                    List<SinhVien> sinhViens = new List<SinhVien>();
                    if (sinhVien.Tables.Count > 0 && sinhVien.Tables["SinhVien"].Rows.Count > 0)
                    {
                        foreach (DataRow row in sinhVien.Tables["SinhVien"].Rows)
                        {
                            SinhVien sv = new SinhVien
                            {
                                MSSV = (string)row["MSSV"],
                                TenSV = (string)row["TenSV"],
                                NgaySinh = (DateTime)row["NgaySinh"],
                                Lop = (string)row["Lop"],
                                Nu = bool.Parse(row["GioiTinh"].ToString()),
                                DienThoai = (string)row["DienThoai"],
                                DiaChi = (string)row["DiaChi"],
                                Diem = float.Parse(row["Diem"].ToString())
                            };
                            sinhViens.Add(sv);
                        }
                    }

                    return sinhViens;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // SUA
        public override bool Modify(SinhVien model)
        {
            try
            {
                string sql = $"EXEC ModifyStudent '{model.MSSV}', N'{model.TenSV}', '{model.NgaySinh}', '{model.Lop}', {model.Nu}, '{model.DienThoai}', N'{model.DiaChi}', {model.Diem}";
                int res = database.ExecuteNonQuery(sql, CommandType.Text);
                return res > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}