import { Task } from "./task.model";
import { TaskService } from "./task.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./task-edit.component.html");
const styles = require("./task-edit.component.scss");

export class TaskEditComponent extends HTMLElement {
    constructor(
		private _taskService: TaskService = TaskService.Instance,
		private _router: Router = Router.Instance
		) {
        super();
		this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return [
            "task-id",
            "story-id"
        ];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
		this._bind();
		this._addEventListeners();
    }
    
	private _bind() {
        this._titleElement.textContent = "Create task";
        this._descriptionEditor = new EditorComponent(this._descriptionElement);

        if (this.taskId) {
            this._taskService.getById(this.taskId).then((results: string) => { 
                var resultsJSON: Task = JSON.parse(results) as Task;                
                this._nameInputElement.value = resultsJSON.name;  
                this._descriptionEditor.setHTML(resultsJSON.description);            
            });
            this._titleElement.textContent = "Edit Task";
        } else {
            this._deleteButtonElement.style.display = "none";
        } 	
	}

	private _addEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);	
	}

    public onSave() {
        var task = {
            id: this.taskId,
            storyId: this.storyId,
            name: this._nameInputElement.value,
            description: this._descriptionEditor.text
        } as Task;
        
        this._taskService.add(task).then((results) => {
			this._router.navigate(["task","list"]);
        });
    }

    public onDelete() {        
        this._taskService.remove({ id: this.taskId }).then((results) => {
            this._router.navigate(["task","list"]);
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {

            case "task-id":
                this.taskId = newValue;
                break;

            case "story-id":
                this.storyId = newValue;
                break;
        }        
    }

    public taskId: number;
    public storyId: number;

    private _descriptionEditor: EditorComponent;
    private get _descriptionElement(): HTMLElement { return this.querySelector(".task-edit-description") as HTMLElement; }
	private get _titleElement(): HTMLElement { return this.querySelector(".task-edit-title") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-task-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-task-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".task-name") as HTMLInputElement;}
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-task-edit`,TaskEditComponent));