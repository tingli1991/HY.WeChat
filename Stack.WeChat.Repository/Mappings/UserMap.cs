/**************************************************************************
*   
*   =======================================================================
*   CLR 版本    ：4.0.30319.42000
*   命名空间    ：Stack.WeChat.Repository.Models.Mapping
*   文件名称    ：UserMap.cs
*   =======================================================================
*   创 建 者    ：李廷礼
*   创建日期    ：2019/6/26 16:12:03 
*   邮    箱    ：litingxian@live.cn
*   个人主站    ：https://github.com/tingli1991
*   功能描述    ：
*   使用说明    ：
*   ========================================================================
*   修改者      ：
*   修改日期    ：
*   修改内容    ：
*   ========================================================================
*  
***************************************************************************/


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stack.WeChat.Repository.Models;

namespace Stack.WeChat.Repository.Mappings
{
    /// <summary>
    /// 用户表结构映射关系
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// 关系配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");//设置表名
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UnionId).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.AppId).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.OpenId).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.GroupId).HasDefaultValue(0);
            builder.Property(e => e.NickName).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.Sex).HasDefaultValue(0);
            builder.Property(e => e.City).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(e => e.Province).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(e => e.Country).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(e => e.Language).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.HeadimgUrl).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(e => e.Subscribe).HasDefaultValue(false);
            builder.Property(e => e.Subscribe_Time).HasDefaultValue(0);
            builder.Property(e => e.Subscribe_Scene).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.Tagid_List).HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(e => e.Qr_Scene).HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(e => e.Qr_Scene_Str).HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(e => e.Remark).HasColumnType("nvarchar").HasMaxLength(2000);
        }
    }
}