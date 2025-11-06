-- incidents definition

CREATE TABLE "incidents" (
    "assignment_group" TEXT,
    "number" TEXT,
    "state" TEXT,
    "caller" TEXT,
    "assigned_to" TEXT,
    "priority" TEXT,
    "created" TEXT,
    "updated" TEXT,
    "short_description" TEXT,
    "sla_due" TEXT,
    "configuration_item" TEXT,
    "resolved" TEXT,
    "email" TEXT
, local_status TEXT, current_incident TEXT, local_priority TEXT DEFAULT ('5'), issue_type TEXT DEFAULT ('N/A'));

-- notes definition

CREATE TABLE notes (
	"number" TEXT,
	"description" TEXT
);


CREATE TABLE last_imported (
    "successful" NUMBER,
    "date_imported" TEXT
);