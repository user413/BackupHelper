drop table if exists specified_file_or_ext;
drop table if exists specified_directory;
drop table if exists option;
drop table if exists profile;

create table profile (
	profile_id integer primary key autoincrement not null,
	profile_listview_index integer not null,
	profile_name text not null,
	profile_time_created text not null,
	profile_last_time_modified text not null,
	profile_last_time_executed text not null,
	profile_group text not null
);

create table option (
	opt_id integer primary key autoincrement not null,
	profile_id integer not null,
	opt_listview_index integer not null,
	opt_source_path text not null,
	opt_destiny_path text not null,
	opt_include_subfolders integer not null,
	opt_keep_origin_files integer not null,
	opt_clean_destiny_dir integer not null,
	opt_delete_uncommon_files integer not null,
	opt_filter_filenames_and_exts integer not null, --opt_allowignore_file_ext integer not null, --changed
	opt_filter_directories integer not null, --added
	opt_spec_filenames_and_exts_mode integer not null,
	opt_spec_directories_mode integer not null, --added
	opt_filename_conflict_method integer not null,
	opt_reenumerate_renamed_files integer not null,
	opt_max_kept_renamed_file_count integer not null,
	foreign key (profile_id) references profile (profile_id)
);

create table specified_file_or_ext (
	spec_id integer primary key autoincrement not null,
	opt_id integer not null,
	spec_name text not null,
	foreign key (opt_id) references option (opt_id)
);

create table specified_directory ( --added
	spec_id integer primary key autoincrement not null,
	opt_id integer not null,
	spec_name text not null,
	foreign key (opt_id) references option (opt_id)
);


delete from sqlite_sequence;