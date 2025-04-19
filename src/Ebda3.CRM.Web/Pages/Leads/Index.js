$(function () {
    var l = abp.localization.getResource('CRM');

    var dataTable = $('#LeadsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                ebda3.cRM.leads.lead.getAllLeads),
            columnDefs: [
                {
                    title: l('firstName'),
                    data: "firstName"
                },
            ]
        })
    );
});
