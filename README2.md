#REDCap @ Virginia commonwealth University
__Latest_ Version 7.4.21 LTS Available__
<table>
    <thead><p style="font-weight:bold; color:#FFBA00">Environment Information</p></thead>
    <tr>
        <td>OS</td>
        <td>Apache</td>
        <td>PHP</td>
    </tr>
    <tr>
        <td>RHEL 6.7</td>
        <td>2.2</td>
        <td>7.1.7</td>
    </tr>
</table>

__Location: https://redcap.vcu.edu__

__Current version installed on Production: v7.4.10__

__Current version installed on Test: v7.4.11__

__Getting Started__

The latest version of REDCap might not be the currently installed version of REDCap for VCU. Please update as necessary.
Please follow the directions carefully. 

> All redcap versions available on this repository contains all the necessary modifications
required to install REDCap, along with the RAM (hook) app. Future plugins or hooks developed and officially released
for VCU could be added prior to installation of REDCap.

> Installing plugins and hooks for new versions of REDCap requires modifications to original source code files.
> The steps below guides you through copy/paste the codes into the files.
> Keep in mind, each new version of REDCap could have slightly increased number of lines of code, so the number listed below
> might not be exactly the same. You'll need to decipher that as you copy/paste.

__It is recommended that you look at previous versions of REDCap for comparison prior to completing the below tasks.__

> __The following steps are for upgrading REDCap for VCU.__
> __Obtaining redcap installation files.__
<ol style="color:#000000; font-style:oblique; font-weight:bold">
    <li>Thoroughly install and test software prior to installing on production.</li>
    <li>Create change management ticket on proposed time and date. (https://servicedesk.vcu.edu)</li>
    <li>Requirements: VCU eID. You'll also need approval from Manager (at least for REDCap)</li>
    <li>Create a new service desk ticket for elevated access to the redcap production database. (mysql-secure2.vcu.edu You are required to use your own credentials to run the sql scripts provided by the REDCap install process)</li>
    <li>Do not run the upgrade scripts using the service account</li>
    <li>Submit this ticket using servicedesk.vcu.edu, go to Applications > Database > MySQL Database request</li>
    <li>Once that has been approved, you'll be able to execute sql scripts on the redcap production database (under your eid).</li>
    <li>Log onto the server / SSH into redcap server (redcap.vcu.edu)</li>
    <li>locate the public redcap folder: cd \var\www\html (app root)</li>
    <li>cd into the VCU_REDCap repository folder</li>
    <li>git pull , this command will update to the latest version of the repository</li>
    <li>Copy the version folder you want to upgrade to: cp -avr VCU_REDCap/redcap/redcap_v6.16.6 /redcap (copies redcap_v6.16.6 folder into /redcap)</li>
    <li>The new version of REDCap is now available to REDCap, go to the Control Panel to start upgrade process.</li>
	<li>Create new SQL on DBForge or MySQL Workbench, paste the script, and execute the script. Note that redcap production databse is mysql-secure2.vcu.edu while redcap test is mysqltest2.vcu.edu
</ol>

__This repository includes the hooks file__
> Includes /hooks/hooks.php bootstrap file

>__What files are modified for each REDCap version?__
> Copy the following provided code to their respective locations and files.

__redcap\version\Classes\Hooks.php --> below redcap_save_record($result)__
```php
	/**
     * VCU Redcap Access Manager Hook
     * @param mixed $result
     */
	 public static function bic_ram_redcap_request_project($result){
        // Don't return anything
    }
```

__redcap\version\ProjectGeneral\create_project_form.php --> line 69, between <?php echo $lang["create_project_02"] ?></div></td></tr> AND <tr id="row_purpose" valign="top">__
```php
	<?php
	// ------------REDCap Hook injection point ------------
	Hooks::call('bic_ram_redcap_request_project', array());
	?>
```

__redcap\version\ProjectGeneral\create_project.php --> line 143, between "db_query("insert into redcap_events_forms (event_id, form_name) select '$this_event_id', form_name from redcap_events_forms where event_id = {$row2['event_id']}");}}" AND "// Copy some defined project-level values from the project being copied"__
```php
    // REDCap Hook injection point --------------------------------
    Hooks::call('bic_ram_redcap_request_project', array());

```
__redcap\version\ProjectGeneral\create_project.php --> line 577, between "/* * * CREATING A NEW PROJECT*/ else {" AND "// Logging"__
```php
    // REDCap Hook injection point --------------------------------
    Hooks::call('bic_ram_redcap_request_project', array());
    // REDCap Hook injection point --------------------------------
```
__redcap\version\Resources\js\base.js --> starting line 4797, between Function "setFieldsCreateFormChk() {if ($('#app_title').val().length < 1) {simpleDialog('Please provide a project title.','Missing title'); return false; }" AND Function "if (page != "ProjectGeneral/copy_project_form.php") {"__
```js
    // -- Begin Redcap Access Manager -- 1.1.5.1
	if (page != "ProjectSetup/index.php") {
	    var ramWorkPhone = $('#ram_work_phone').val() ? $('#ram_work_phone').val() : '';
	    var ramManager = $('#ram_manager').val() ? $('#ram_manager').val() : '';
	    var ramManagerEmail = $('#ram_manager_email').val() ? $('#ram_manager_email').val() : '';

	    // We'll use the base functions to get values from radio buttons
	    var ramPhidata = $("input[name='ram_phi']:checked").val();
	    if (ramPhidata) {
	        ramPhidata = getRadioButtonValue($("input[name='ram_phi']"));
	    }
	    var ramCernerData = $("input[name='ram_cerner_data']:checked").val();
	    if (ramCernerData) {
	        ramCernerData = getRadioButtonValue($("input[name='ram_cerner_data']"))
	    }
	    var ramIdxData = $("input[name='ram_idx_data']:checked").val();
	    if (ramIdxData) {
	        ramIdxData = getRadioButtonValue($("input[name='ram_idx_data']"));
	    }
	    var ramSsnData = $("input[name='ram_ssn']:checked").val();
	    if (ramSsnData) {
	        ramSsnData = getRadioButtonValue($("input[name='ram_ssn']"));
	    }
	    var ramOtherSensitiveData = $("input[name='ram_other_sensitive_data']:checked").val();
	    if (ramOtherSensitiveData) {

	        ramOtherSensitivedata = getRadioButtonValue($("input[name='ram_other_sensitive_data']"));
	    }

	    if (!isUSPhoneNumber(ramWorkPhone)) {
	        simpleDialog('Please provide a valid US phone number.', 'Missing Phone Number');
	        return false;
	    }
	    if (!ramManager) {
	        simpleDialog('Please provide Manager or Supervisor name.', 'Missing Manager Information');
	        return false;
	    }
	    if (!isEmail(ramManagerEmail)) {
	        simpleDialog('Please provide a valid Manager or Supervisor email.', 'Missing Manager\'s Email Information');
	        return false;
	    }
	    if (typeof ramCernerData === 'undefined') {
	        simpleDialog('Please provide a choice for Cerner Information.', 'Missing Cerner Information');
	        return false;
	    }
	    if (typeof ramIdxData === 'undefined') {
	        simpleDialog('Please provide a choice for GE IDX Information.', 'Missing IDX Information');
	        return false;
	    }
	    if (typeof ramPhidata === 'undefined') {
	        simpleDialog('Please provide a choice for Protected Health Information.', 'Missing PHI Information');
	        return false;
	    }
	    if (typeof ramSsnData === 'undefined') {
	        simpleDialog('Please provide a choice for Social Security Information.', 'Missing SSN Information');
	        return false;
	    }
	    if (typeof ramOtherSensitiveData === 'undefined') {
	        simpleDialog('Please provide a choice for other sensitive information.', 'Missing Other Sensitive Information');
	        return false;
	    }
	}
    // -- End Redcap Access Manager -- 1.1.5.1	
```

__redcap\version\LanguageUpdater\English.ini --> replace line 5959, rights_162__
```ini
rights_162 = "Give them custom user rights or assign them to a role.
	<div class="red">(e.g., add user by <u>eid</u> and not by <u>eid@mail.edu</u>)</div>"

```

__redcap\version\LanguageUpdater\English.ini --> replace line 6019, rights_216__
```ini

rights_216 = "This page may be used for granting users access to this project and for managing the user privileges of those users.
	You may also create roles to which you may assign users (optional). User roles are useful when you will have several users with the same
	privileges because they allow you to easily add many users to a role in a much faster manner than setting their
	user privileges individually. Roles are also a nice way to categorize users within a project. In the box below you
	may add/assign users or create new roles, and the table at the bottom allows you to make modifications to
	any existing user or role in the project, as well as view a glimpse of their user privileges.<br/>
	<div class="green"><strong>Note: </strong>A user must be added using eID username.  Adding a user by email address will not work.</div>"


```

