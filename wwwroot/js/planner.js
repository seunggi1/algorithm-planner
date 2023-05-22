const algoType = document.querySelector('.algo-type');
const algoName = document.querySelector('.algo-name');
const algoURL = document.querySelector('.algo-url');
const saveBtn = document.querySelector('button');
const sidebarTypes = document.querySelectorAll('.sidebar-types');
const callModalBtn = document.querySelectorAll('.btn-update-modal');
const updateBtn = document.querySelector('#btnUpdate')
const modal = {
    name: document.querySelector('#name'),
    id: document.querySelector('#id'),
    type: document.querySelector('#type'),
    lastStudyDate: document.querySelector('#lastStudyDate'),
    url: document.querySelector('#url'),
    comment : document.querySelector('#comment')
}

saveBtn.addEventListener('click', onClickSaveBtn);

callModalBtn.forEach((elem) => {
    elem.addEventListener('click', onClickCallModalBtn);
});

updateBtn.addEventListener('click', onClickUpdateBtn);

sidebarTypes.forEach((elem) => {
    elem.addEventListener('click', onClickSidebar)
});

function onClickSaveBtn() {
    fetch('/planner', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ type: algoType.value, name: algoName.value, url: algoURL.value }),
    }).then((response) => {

        if (response.ok) {
            toastr.success('insert completed!')

        } else {
            throw new Error(response.statusText);
        }
    }).catch((error) => {
        toastr.error(error);
    });
}

function onClickUpdateBtn() {
    const id = modal.id.value;
    const type = modal.type.selectedIndex;
    const name = modal.name.value;
    const url = modal.url.value;
    const comment = modal.comment.value;
       
    fetch('/planner', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id, type, name, url, comment })
    }).then((response) => {

        if (response.ok) {
            toastr.success('update completed!');
            onActiveUpdateModal(false);

        } else {
            throw new Error(response.statusText);
        }
    }).catch((error) => {
        toastr.error(error);
    });
}

function onClickSidebar(elem) {
    const type = elem.target.closest('li').dataset['type'];

/*    document.querySelectorAll('.planner-types').forEach(elem => {
        elem.classList.add('d-none')
    })

    document.querySelector(`.planner-types[data-type="${type}"]`)
        .classList
        .remove('d-none');
*/

    window.scrollBy(0, document.querySelector(`.planner-types[data-type="${type}"]`).closest('.card').clientHeight);
}

function onClickCallModalBtn(elem) {
    const parent = elem.target.closest('li');
    const type = elem.target.closest('ul').dataset['type'];
    const url = parent.querySelector('a');
    const lastDate = parent.querySelector('span');

    modal.id.value = parent.dataset['id'];
    modal.comment.value = parent.dataset['comment'];
    modal.type.options[type].selected = true;    
    modal.name.value = url.textContent;
    modal.url.value = url.getAttribute('href');
    modal.lastStudyDate.textContent = `Last updated : ${lastDate.textContent} `;
        
    onActiveUpdateModal(true);
}

function onActiveUpdateModal(isActive) {
    $('#updateModal').modal(isActive ? 'show' : 'hide');
}
