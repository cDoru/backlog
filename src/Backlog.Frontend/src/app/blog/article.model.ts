import { Author } from "./author.model";
import { Category } from "../categories";
import { Tag } from "../tags";

export class Article { 
    public id: number;
    public author: Author;
    public authorId: string;
    public title: string;
    public slug: string;
    public htmlContent: string;
    public isPublished: boolean;
    public published: string;

    public categories: Array<Category> = [];
    public tags: Array<Tag> = [];
}