$(function () {
   var l = abp.localization.getResource('CRM');

   var editModal = new abp.ModalManager(abp.appPath + 'Contacts/EditContactModal');
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
                title: l('Actions'),
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            action: function(data) {
                                editModal.open({ id: data.record.id })
                                //abp.notify.success("result");
                            }
                        },
                        {
                            text: l('Delete'),
                            confirmMessage: function (data) {
                                return l('LeadDeletionConfirmationMessage',
                                    data.record.firstName + ' ' + data.record.lastName);
                            },
                            action: function(data) {
                                ebda3.cRM.leads.lead.deleteLead(data.record.id)
                                    .then(function() {
                                        abp.message.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    })
                            }
                        }
                    ]
                }  
              },
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
                  title: l('Company'),
                  data: 'company'
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
   
   var createModal = new abp.ModalManager(abp.appPath + 'Contacts/CreateLeadModal');
   createModal.onResult(function () {
       dataTable.ajax.reload();
   });
    $('#BtnNewContact').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    
    //To Update the data.
    editModal.onResult(function () {
        dataTable.ajax.reload();
    })
});