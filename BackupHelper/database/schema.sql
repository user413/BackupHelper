drop table if exists specified_file_or_ext;
drop table if exists option;
drop table if exists profile;
drop table if exists allowonly_ext;
drop table if exists ignore_ext;
drop table if exists transfer_method;

CREATE TABLE [profile] (
  [profile_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [profile_listview_index] INTEGER NOT NULL
, [profile_name] text NOT NULL
, [profile_time_created] text NOT NULL
, [profile_last_time_modified] text NOT NULL
, [profile_last_time_executed] text NOT NULL
);

CREATE TABLE [option] (
  [opt_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [profile_id] INTEGER NOT NULL
, [opt_listview_index] INTEGER NOT NULL
, [opt_source_path] text NOT NULL
, [opt_destiny_path] text NOT NULL
, [opt_move_subfolders] tinyint NOT NULL
, [opt_keep_origin_files] tinyint NOT NULL
, [opt_clean_destiny_dir] tinyint NOT NULL
, [opt_delete_uncommon_files] tinyint NOT NULL
, [opt_allowignore_file_ext] tinyint not null
, [opt_spec_filenames_and_exts_mode] tinyint not null
, [opt_filename_conflict_method] tinyint not null
, CONSTRAINT [FK_option_0_0] FOREIGN KEY ([profile_id]) REFERENCES [profile] ([profile_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE [specified_file_or_ext] (
  [spec_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [opt_id] INTEGER NOT NULL
, [spec_name] text NOT NULL
, CONSTRAINT [FK_ignore_ext_0_0] FOREIGN KEY ([opt_id]) REFERENCES [option] ([opt_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);

delete from sqlite_sequence;