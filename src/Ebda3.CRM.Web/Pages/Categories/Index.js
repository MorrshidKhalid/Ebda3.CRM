$(function () {
    var l = abp.localization.getResource('CRM');

    var editModal = new abp.ModalManager(abp.appPath + 'Categories/EditCategoryModal');
    var dataTable = $('#CategoriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                ebda3.cRM.categories.category.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('Edit'),
                                action: function(data) {
                                    editModal.open({ id: data.record.id })
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('CategoryDeletionConfirmationMessage',
                                        data.record.name);
                                },
                                action: function(data) {
                                    ebda3.cRM.categories.category
                                        .delete(data.record.id)
                                        .then(function() {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Categories/CreateCategoryModal');
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewCategoryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    })
});
