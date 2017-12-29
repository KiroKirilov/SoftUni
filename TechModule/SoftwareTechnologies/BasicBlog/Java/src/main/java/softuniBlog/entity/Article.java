package softuniBlog.entity;


import com.sun.javafx.geom.transform.Identity;

import javax.persistence.*;

@Entity
@Table(name="articles")
public class Article {
    private Integer id;
    private String title;
    private String content;
    private User author;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Column(columnDefinition = "text", nullable = false)
    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    @ManyToOne(optional = false)
    public User getAuthor() {
        return author;
    }

    public void setAuthor(User author) {
        this.author = author;
    }

    public Article() {
    }

    public Article(String title, String content, User author) {

        this.id = id;
        this.title = title;
        this.content = content;
        this.author = author;
    }

    @Transient
    public String getSummary(){
        if (this.getContent().length()<150)
            return this.getContent();
        else
            return this.getContent().substring(0,150)+"...";
    }
}
