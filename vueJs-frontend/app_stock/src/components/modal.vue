<template>
	<div ref="mRef" class="modal" tabindex="-1" role="dialog" data-bs-backdrop="static" data-bs-keyboard="false" aria-labelledby="staticBackdropLabel" aria-hidden="true">
		<div :class="'modal-dialog' + (size ? (' modal-' + size) : '')" :style="width ? { 'max-width' : width }: null">
			<div class="modal-content">
				<div class="modal-header" style="background-color: rgba(0, 0, 0, 0.03)">
					<h6 class="modal-title">{{ title }}</h6>
					<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" />
				</div>
				<div class="modal-body">
					<slot/>
				</div>
				<div v-if="$slots.footer" class="modal-footer text-center">
					<slot name="footer"/>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { Modal } from 'bootstrap';
import { ref, reactive } from 'vue';

export default {
	name: 'Modal',
	//inheritAttrs: false,
	props: {
		title: { type: String, default: '' },
		size: { type: String, default: '' },
		width: { type: String, default: null}
		//hidden: { type: Function, default() {} }
		//static: { type: Boolean, default: false }
	},
	emits: ['hidden'],
	setup(props, { emit }) {
		const mRef = ref();
		var mFrm = reactive(null);

		const show = function() {
			if (!mFrm) {
				mFrm = new Modal(this.$el, {});

				//if (props.hidden)
					this.$el.addEventListener('hidden.bs.modal', () => {
						emit('hidden');
					});
			}

			mFrm.show();
		};

		const hide = function() {
			if (mFrm) {
				mFrm.hide();
			}
		};

		const toggle = function() {
			if (mFrm) {
				mFrm.toggle();
			}
		};

		return { mRef, mFrm, show, hide, toggle };
	},
}
</script>
