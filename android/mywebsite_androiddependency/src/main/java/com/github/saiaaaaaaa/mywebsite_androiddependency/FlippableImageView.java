package com.github.saiaaaaaaa.mywebsite_androiddependency;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.os.Handler;
import android.util.AttributeSet;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.content.res.AppCompatResources;

public class FlippableImageView extends androidx.appcompat.widget.AppCompatImageView {

    Context context;
    int rotation = 0;
    boolean isFlipped = false;
    Bitmap frontImage, backImage;
    int speed;

    public enum Speed{
        SLOW(5),
        NORMAL(15),
        FAST(30);

        final int value;

        Speed(int value){
            this.value = value;
        }
    }

    public FlippableImageView(@NonNull Context context) {
        super(context);
        this.context = context;
        speed = Speed.NORMAL.value;
    }

    public FlippableImageView(@NonNull Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        this.context = context;
        speed = Speed.NORMAL.value;
    }

    public FlippableImageView(@NonNull Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        this.context = context;
        speed = Speed.NORMAL.value;
    }

    public FlippableImageView(@NonNull Context context, Speed speed) {
        super(context);
        this.context = context;
        this.speed = speed.value;
    }

    public FlippableImageView(@NonNull Context context, Speed speed, @Nullable AttributeSet attrs) {
        super(context, attrs);
        this.context = context;
        this.speed = speed.value;
    }

    public FlippableImageView(@NonNull Context context, Speed speed, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        this.context = context;
        this.speed = speed.value;
    }

    public void setSpeed(Speed speed){
        this.speed = speed.value;
    }

    public void setFrontImage(int resourceId){
        frontImage = ((BitmapDrawable) AppCompatResources.getDrawable(context, resourceId)).getBitmap();
    }

    public void setFrontImage(Drawable drawable){
        frontImage = ((BitmapDrawable) drawable).getBitmap();
    }

    public void setBackImage(int resourceId){
        backImage = ((BitmapDrawable) AppCompatResources.getDrawable(context, resourceId)).getBitmap();
    }

    public void setBackImage(Drawable drawable){
        backImage = ((BitmapDrawable) drawable).getBitmap();
    }

    public void flip(){
        new Handler().post(new Runnable() {
            @Override
            public void run() {
                if (!isFlipped){
                    rotation += speed;
                    if (rotation >= 90 && rotation < 180){
                        setRotationY(rotation);
                        new Handler().post(this);
                        setImageBitmap(backImage);
                    } else if (rotation < 180){
                        setRotationY(rotation);
                        new Handler().post(this);
                    }
                    if (rotation == 180){
                        isFlipped = true;
                        setRotationY(rotation);
                    }
                } else {
                    rotation -= speed;
                    if (rotation >= 90 && rotation < 180){
                        setRotationY(rotation);
                        new Handler().post(this);
                    } else if (rotation > 0 && rotation < 90){
                        setRotationY(rotation);
                        new Handler().post(this);
                        setImageBitmap(frontImage);
                    }
                    if (rotation == 0){
                        isFlipped = false;
                        setRotationY(rotation);
                    }
                }
            }
        });
    }

    public boolean isFlipped(){
        return isFlipped;
    }
}