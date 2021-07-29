using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace gp2.Models
{
    public partial class Gp2Context : DbContext
    {
        public Gp2Context()
        {
        }

        public Gp2Context(DbContextOptions<Gp2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actcollection> Actcollections { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Scenicspot> Scenicspots { get; set; }
        public virtual DbSet<Scenicview> Scenicviews { get; set; }
        public virtual DbSet<Spotcollection> Spotcollections { get; set; }
        public virtual DbSet<Stacollection> Stacollections { get; set; }
        public virtual DbSet<Strategy> Strategies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;user id=root;password=123;database=gp2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Actcollection>(entity =>
            {
                entity.HasKey(e => e.ActcId)
                    .HasName("PRIMARY");

                entity.ToTable("actcollection");

                entity.Property(e => e.ActcId)
                    .HasColumnType("int(11)")
                    .HasColumnName("actc_id");

                entity.Property(e => e.ActcActid)
                    .HasColumnType("int(11)")
                    .HasColumnName("actc_actid");

                entity.Property(e => e.ActcUserid)
                    .HasColumnType("int(11)")
                    .HasColumnName("actc_userid");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.ActId)
                    .HasName("PRIMARY");

                entity.ToTable("activity");

                entity.HasIndex(e => e.ActWriter, "act_user_writer");

                entity.Property(e => e.ActId)
                    .HasColumnType("int(11)")
                    .HasColumnName("act_id");

                entity.Property(e => e.ActBegintime).HasColumnName("act_begintime");

                entity.Property(e => e.ActContent).HasColumnName("act_content");

                entity.Property(e => e.ActEndtime).HasColumnName("act_endtime");

                entity.Property(e => e.ActNum)
                    .HasColumnType("int(11)")
                    .HasColumnName("act_num");

                entity.Property(e => e.ActPhone)
                    .HasMaxLength(255)
                    .HasColumnName("act_phone");

                entity.Property(e => e.ActPic).HasColumnName("act_pic");

                entity.Property(e => e.ActSpend)
                    .HasMaxLength(255)
                    .HasColumnName("act_spend");

                entity.Property(e => e.ActTime)
                    .HasMaxLength(255)
                    .HasColumnName("act_time");

                entity.Property(e => e.ActTitle)
                    .HasMaxLength(255)
                    .HasColumnName("act_title");

                entity.Property(e => e.ActWriter)
                    .HasColumnType("int(255)")
                    .HasColumnName("act_writer");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasIndex(e => e.PostSid, "post_sta_sid");

                entity.HasIndex(e => e.PostUserid, "post_user_userid");

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_id");

                entity.Property(e => e.PostContent)
                    .HasMaxLength(255)
                    .HasColumnName("post_content");

                entity.Property(e => e.PostPubdate).HasColumnName("post_pubdate");

                entity.Property(e => e.PostRank)
                    .HasColumnType("int(255)")
                    .HasColumnName("post_rank");

                entity.Property(e => e.PostSid)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_sid");

                entity.Property(e => e.PostTitle)
                    .HasMaxLength(255)
                    .HasColumnName("post_title");

                entity.Property(e => e.PostUserid)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_userid");
            });

            modelBuilder.Entity<Scenicspot>(entity =>
            {
                entity.HasKey(e => e.SpotId)
                    .HasName("PRIMARY");

                entity.ToTable("scenicspot");

                entity.Property(e => e.SpotId)
                    .HasColumnType("int(11)")
                    .HasColumnName("spot_id");

                entity.Property(e => e.SpotAddress)
                    .HasMaxLength(255)
                    .HasColumnName("spot_address");

                entity.Property(e => e.SpotCity)
                    .HasMaxLength(255)
                    .HasColumnName("spot_city");

                entity.Property(e => e.SpotInformation)
                    .HasColumnType("text")
                    .HasColumnName("spot_information");

                entity.Property(e => e.SpotLat)
                    .HasPrecision(10, 6)
                    .HasColumnName("spot_lat");

                entity.Property(e => e.SpotLng)
                    .HasPrecision(10, 6)
                    .HasColumnName("spot_lng");

                entity.Property(e => e.SpotLove)
                    .HasColumnType("int(11)")
                    .HasColumnName("spot_love");

                entity.Property(e => e.SpotName)
                    .HasMaxLength(255)
                    .HasColumnName("spot_name");

                entity.Property(e => e.SpotOpentime)
                    .HasColumnType("text")
                    .HasColumnName("spot_opentime");

                entity.Property(e => e.SpotPicture)
                    .HasColumnType("text")
                    .HasColumnName("spot_picture");

                entity.Property(e => e.SpotProvince)
                    .HasMaxLength(255)
                    .HasColumnName("spot_province");
            });

            modelBuilder.Entity<Scenicview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("scenicview");

                entity.Property(e => e.ViewId)
                    .HasMaxLength(255)
                    .HasColumnName("view_id");

                entity.Property(e => e.ViewSceid)
                    .HasMaxLength(255)
                    .HasColumnName("view_sceid");

                entity.Property(e => e.ViewTimes)
                    .HasMaxLength(255)
                    .HasColumnName("view_times");

                entity.Property(e => e.ViewUserid)
                    .HasMaxLength(255)
                    .HasColumnName("view_userid");
            });

            modelBuilder.Entity<Spotcollection>(entity =>
            {
                entity.HasKey(e => e.SpotcId)
                    .HasName("PRIMARY");

                entity.ToTable("spotcollection");

                entity.HasIndex(e => e.SpotcSpotid, "spotc_spot_id");

                entity.HasIndex(e => e.SpotcUserid, "spotc_user_id");

                entity.Property(e => e.SpotcId)
                    .HasColumnType("int(11)")
                    .HasColumnName("spotc_id");

                entity.Property(e => e.SpotcSpotid)
                    .HasColumnType("int(11)")
                    .HasColumnName("spotc_spotid");

                entity.Property(e => e.SpotcUserid)
                    .HasColumnType("int(11)")
                    .HasColumnName("spotc_userid");
            });

            modelBuilder.Entity<Stacollection>(entity =>
            {
                entity.HasKey(e => e.StacId)
                    .HasName("PRIMARY");

                entity.ToTable("stacollection");

                entity.HasIndex(e => e.StacStaid, "stac_sta_id");

                entity.HasIndex(e => e.StacUserid, "stac_user_id");

                entity.Property(e => e.StacId)
                    .HasColumnType("int(11)")
                    .HasColumnName("stac_id");

                entity.Property(e => e.StacStaid)
                    .HasColumnType("int(11)")
                    .HasColumnName("stac_staid");

                entity.Property(e => e.StacUserid)
                    .HasColumnType("int(11)")
                    .HasColumnName("stac_userid");
            });

            modelBuilder.Entity<Strategy>(entity =>
            {
                entity.HasKey(e => e.StaId)
                    .HasName("PRIMARY");

                entity.ToTable("strategy");

                entity.HasIndex(e => e.StaWriter, "sta_user_id");

                entity.Property(e => e.StaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_id");

                entity.Property(e => e.StaContent).HasColumnName("sta_content");

                entity.Property(e => e.StaCosts)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_costs");

                entity.Property(e => e.StaInfo)
                    .HasMaxLength(255)
                    .HasColumnName("sta_info");

                entity.Property(e => e.StaLove)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_love");

                entity.Property(e => e.StaPic).HasColumnName("sta_pic");

                entity.Property(e => e.StaPopulation)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_population");

                entity.Property(e => e.StaPubdate).HasColumnName("sta_pubdate");

                entity.Property(e => e.StaRequiredtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_requiredtime");

                entity.Property(e => e.StaScenic)
                    .HasMaxLength(255)
                    .HasColumnName("sta_scenic");

                entity.Property(e => e.StaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("sta_title");

                entity.Property(e => e.StaViews)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_views");

                entity.Property(e => e.StaWriter)
                    .HasColumnType("int(11)")
                    .HasColumnName("sta_writer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.Isdeleted)
                    .HasColumnType("int(11)")
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0代表存在 1代表删除");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(11)
                    .HasColumnName("user_phone");

                entity.Property(e => e.UserPic).HasColumnName("user_pic");

                entity.Property(e => e.UserSex)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_sex");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
