drop table if exists allowonly_ext;drop table if exists ignore_ext;drop table if exists transfer_method;drop table if exists option;drop table if exists profile;

CREATE TABLE [transfer_method] (
  [method_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [method_text] text NOT NULL
);
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
, [opt_listview_index] INTEGER NOT NULL
, [method_id] integer not null
, [profile_id] bigint NOT NULL
, [opt_source_path] text NOT NULL
, [opt_destiny_path] text NOT NULL
, [opt_move_subfolders] tinyint NOT NULL
, [opt_keep_origin_files] tinyint NOT NULL
, [opt_clean_destiny_dir] tinyint NOT NULL
, [opt_delete_uncommon_files] tinyint NOT NULL
, [opt_allowignore_file_ext] tinyint not null
, CONSTRAINT [FK_option_0_0] FOREIGN KEY ([profile_id]) REFERENCES [profile] ([profile_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, foreign key (method_id) references transfer_method(method_id)
);
CREATE TABLE [allowonly_ext] (
  [extallowonly_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [opt_id] bigint NOT NULL
, [ext_name] text NOT NULL
, CONSTRAINT [FK_allowonly_ext_0_0] FOREIGN KEY ([opt_id]) REFERENCES [option] ([opt_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [ignore_ext] (
  [extignore_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [opt_id] bigint NOT NULL
, [ext_name] text NOT NULL
, CONSTRAINT [FK_ignore_ext_0_0] FOREIGN KEY ([opt_id]) REFERENCES [option] ([opt_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);

insert into transfer_method(method_id,method_text)values(1,"Do not move");
insert into transfer_method(method_id,method_text)values(2,"Replace all");
insert into transfer_method(method_id,method_text)values(3,"Replace only different files (binary comparison)");
insert into transfer_method(method_id,method_text)values(4,"Rename different files (binary comparison)");

delete from sqlite_sequence;