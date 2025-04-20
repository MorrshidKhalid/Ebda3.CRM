$(function () {
   var l = abp.localization.getResource('CRM');
   
   var dataTable = $('#LeadsTable').DataTable(
       abp.libs.datatables.normalizeConfiguration({
          serverSide: true,
          paging: true,
          order: [[0, "asc"]],
          searching: false,
          scrollX: true,

           ajax: abp.libs.datatables.createAjax
                (ebda3.cRM.leads.lead.getAllLeads),
          columnDefs: [
              {
                  title: l('Full-Name'),
                  data: null,
                  render: function (data, type, row) {
                      return row.firstName + ' ' + row.lastName;
                  }
              },
              {
                  title: l('Email'),
                  data: 'email'
              },
              {
                  title: l('Phone'),
                  data: 'phone'
              },
              {
                  title: l('Camponey'),
                  data: 'camponey'
              },
              {
                  title: l('Industry'),
                  data: 'industry'
              },
              {
                  title: l('Source'),
                  data: 'source',
                  render: function (data) {
                      return l('Enum:Source.' + data);
                  }
              },
              {
                  title: l('Status'),
                  data: 'status',
                  render: function (data) {
                      return l('Enum:Status.' + data);
                  }
              },
              {
                  title: l('Address'),
                  data: null,
                  render: function (data, type, row) {
                      return row.city + ', ' + row.state + ', ' + row.street 
                  }
              },
              {
                  title: l('Zip-Code'),
                  data: 'zipCode'
              }  
          ]
          
       })
   );
    
});