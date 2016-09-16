import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

@Component({
    template: require("./epic-edit-form.component.html"),
    styles: [require("./epic-edit-form.component.scss")],
    selector: "epic-edit-form",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicEditFormComponent implements AfterViewInit {    
    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);
    }

    @Input() public epic: any;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
        name: new FormControl("", [
            Validators.required
        ]),
        description: new FormControl("", [
            Validators.required
        ])
    });
}
